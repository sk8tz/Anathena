﻿namespace Ana.Source.Scanners.ManualScanner
{
    using ScanConstraints;
    using Snapshots;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UserSettings;

    internal class ManualScannerModel : ScannerBase
    {
        public ManualScannerModel() : base("Manual Scan")
        {
            this.ProgressLock = new Object();
        }

        private Snapshot Snapshot { get; set; }

        private ScanConstraintManager ScanConstraintManager { get; set; }

        private Object ProgressLock { get; set; }

        public void SetScanConstraintManager(ScanConstraintManager scanConstraintManager)
        {
            this.ScanConstraintManager = scanConstraintManager;
        }

        public override void Begin()
        {
            // Initialize snapshot
            this.Snapshot = SnapshotManager.GetInstance().GetActiveSnapshot(createIfNone: true).Clone(this.ScannerName);

            if (this.Snapshot == null || this.ScanConstraintManager == null || this.ScanConstraintManager.Count() <= 0)
            {
                this.End();
                return;
            }

            this.Snapshot.SetAllValidBits(true);

            base.Begin();
        }

        protected override void OnUpdate()
        {
            Int32 processedPages = 0;

            // Read memory to get current values
            Parallel.ForEach(
                this.Snapshot.Cast<Object>(),
                SettingsViewModel.GetInstance().ParallelSettings,
                (regionObject) =>
            {
                SnapshotRegion region = regionObject as SnapshotRegion;
                Boolean readSuccess;

                region.ReadAllRegionMemory(out readSuccess, keepValues: true);

                if (!readSuccess)
                {
                    region.SetAllValidBits(false);
                    return;
                }

                // Ignore region if it requires current & previous values, but we cannot find them
                if (this.ScanConstraintManager.HasRelativeConstraint() && !region.CanCompare())
                {
                    region.SetAllValidBits(false);
                    return;
                }

                foreach (SnapshotElementRef element in region)
                {
                    // Enforce each value constraint on the element
                    foreach (ScanConstraint scanConstraint in this.ScanConstraintManager)
                    {
                        switch (scanConstraint.Constraint)
                        {
                            case ConstraintsEnum.Unchanged:
                                if (!element.Unchanged())
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.Changed:
                                if (!element.Changed())
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.Increased:
                                if (!element.Increased())
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.Decreased:
                                if (!element.Decreased())
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.IncreasedByX:
                                if (!element.IncreasedByValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.DecreasedByX:
                                if (!element.DecreasedByValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.Equal:
                                if (!element.EqualToValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.NotEqual:
                                if (!element.NotEqualToValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.GreaterThan:
                                if (!element.GreaterThanValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.GreaterThanOrEqual:
                                if (!element.GreaterThanOrEqualToValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.LessThan:
                                if (!element.LessThanValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.LessThanOrEqual:
                                if (!element.LessThanOrEqualToValue(scanConstraint.ConstraintValue))
                                {
                                    element.SetValid(false);
                                }

                                break;
                            case ConstraintsEnum.NotScientificNotation:
                                if (element.IsScientificNotation())
                                {
                                    element.SetValid(false);
                                }

                                break;
                        }
                    }
                    //// End foreach Constraint
                }
                //// End foreach Element

                lock (this.ProgressLock)
                {
                    processedPages++;
                }
            });
            //// End foreach Region

            base.OnUpdate();
            this.CancelFlag = true;
        }

        /// <summary>
        /// Called when the repeated task completes
        /// </summary>
        protected override void OnEnd()
        {
            this.Snapshot.DiscardInvalidRegions();
            SnapshotManager.GetInstance().SaveSnapshot(this.Snapshot);
            this.CleanUp();
            base.OnEnd();
        }

        private void CleanUp()
        {
            Snapshot = null;
        }
    }
    //// End class
}
//// End namespace