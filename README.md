# OverwatchLogger
[![Sponsor on DonatAlerts](https://img.shields.io/badge/sponsor-alerts-orange.svg)](https://www.donationalerts.com/r/asmrmilo21)
[![Download letest version](https://img.shields.io/badge/download-latest-red.svg)](https://github.com/NOTIF-API/OverwatchLogger/releases)

# What to do when errors are detected
**If you suddenly find an error or a flaw that needs to be corrected. If you see that the plugin is missing something, you can submit a suggestion about what could be added**.
1. You can contact me via [Issues](https://github.com/NOTIF-API/OverwatchLogger/issues).
2. You can contact me via Discord under the name `notifapi` or `NOTIF` if you are looking for connections through servers with SCP or Exiled.

# Configs (Defaults)
```yaml
# Will the plugin be enabled?
is_enabled: true
# Will debug messages be visible?
debug: false
# Hook settings
hook:
# Link to the webhook through which the message will be sent
  hook_url: ''
  # Link to webhook avatar (can be left blank, in which case the avatar posted on Discord will be used)
  hook_avatar: ''
  # Webhook name, used to separate the message with a name (empty form field = name configured in Discord)
  hook_name: 'Role enter time logger'
# Settings for display message in weebhook
log_messages:
# Log message when entering a specific role mode
  entered_message: 'Staff %player% (%steamid%) entered to %role%'
  # Log message when exiting a specific role mode
  exited_message: 'Staff %player% (%steamid%) exited from %role%'
  # Summary message with the results of using the role
  summary_info: 'Round ended, entered roles time count:\n %summary%'
  # View of the line with the total time for the player used N role
  summary: '[%player%] used role %role% %hours% %minutes% %seconds%'
  # Line for seconds
  seconds: '%count% seconds'
  # Line for minutes
  minutes: '%count% minutes'
  # Line for total hours
  hours: '%count% hours'
# List roles for display assgned round time
tracked_roles:
- Overwatch
- Tutorial
# Will the plugin only log server staff
log_only_staff_roles: false
# Groups to be ignored (only if staff logging is enabled)
ignored_groups:
- 'owner'
```

## How edit
**Attention in standard configs all places where the words listed below were mentioned for rearrangement can be used only in the same places but in a different order, do not use words where they were not intended to be used!**
| effect_line | description |
| ------------ | ----- |
| %player%     | Replace to player nickname |
| %count%      | Replace a total formatted time |
| %role%       | Reolace role name |
| %hours%      | Return hours line |
| %minutes%    | Return minutes line | 
| %seconds%    | Return seconds line |
| %summary%    | Return total summary from summary generated lines |
| %steamid%    | Return userid |
