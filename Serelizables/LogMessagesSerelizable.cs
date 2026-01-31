using System.ComponentModel;

namespace OverwatchLogger.Serelizables
{
    public class LogMessagesSerelizable
    {
        [Description("Log message when entering a specific role mode")]
        public string EnteredMessage { get; set; } = "Staff %player% entered to %role%";
        [Description("Log message when exiting a specific role mode")]
        public string ExitedMessage { get; set; } = "Staff %player% exited from %role%";
        [Description("Summary message with the results of using the role")]
        public string SummaryInfo { get; set; } = "Round ended, entered roles time count: %summary%";
        [Description("View of the line with the total time for the player used N role")]
        public string Summary { get; set; } = "[%player%] used role %role% %hours% %minutes% %seconds%";
        [Description("Line for seconds")]
        public string Seconds { get; set; } = "%count% seconds";
        [Description("Line for minutes")]
        public string Minutes { get; set; } = "%count% minutes";
        [Description("Line for total hours")]
        public string Hours { get; set; } = "%count% hours";
    }
}
