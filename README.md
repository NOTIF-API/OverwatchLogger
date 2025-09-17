# OverwatchLogger
[![Sponsor on DonatAlerts](https://img.shields.io/badge/sponsor-alerts-orange.svg)](https://www.donationalerts.com/r/asmrmilo21)
[![Download letest version](https://img.shields.io/badge/download-latest-red.svg)](https://github.com/NOTIF-API/OverwatchLogger/releases)

# What to do when errors are detected
**If you suddenly find an error or a flaw that needs to be corrected. If you see that the plugin is missing something, you can submit a suggestion about what could be added**.
1. You can contact me via [Issues](https://github.com/NOTIF-API/OverwatchLogger/issues).
2. You can contact me via Discord under the name `notifapi` or `NOTIF` if you are looking for connections through servers with SCP or Exiled.

# Configs
```yaml
# Will the plugin be enabled?
is_enabled: true
# Will debug messages be visible?
debug: true
# Webhook link for sending messages
weeb_hook_url: ''
# Overrides the webhook name (if left blank it uses the default one set in discord)
weeb_hook_name: ''
# Overrides the webhook avatar (if left blank it uses the default one set in discord)
weeb_hook_avatar_url: ''
# When the admin turns on the overmatch (any player who has been given this role)
enter_message: 'Staff %player% entered to overwatch mode.'
# When the admin turns off the overmatch (any player who was given this role)
exit_message: 'Staff %player% exited from overwatch mode.'
# Top message, displayed for the total (1 line)
round_end_summary: 'Round ended. Staff''s who used overwatch'
# Message constructor for each player who turned on overmatch in the round
staff_summary: '[%player%] used overwatch %hours% %minutes% %seconds%'
# message replacement for %hours%, where %h% is the total number of hours (if = 0 then the message will not be output)
hhours: '%h% hours'
# message replacement for %minutes%, where %m% is the total number of minutes (if = 0 then the message will not appear)
mminutes: '%m% minutes'
# message replacement for %seconds%, where %s% is the final number of seconds (if = 0 then the message will not be output)
sseconds: '%s% seconds'
```

## How edit
**Attention in standard configs all places where the words listed below were mentioned for rearrangement can be used only in the same places but in a different order, do not use words where they were not intended to be used!**
| effect_line | description |
| ------------ | ----- |
| %player%     | Replace to player display nickname |
| %s%          | Number of seconds |
| %m%          | Number of minuts |
| %h%          | Number of hours |
| %hours%      | Replaced by hhours line |
| %minutes%    | Replaced by mminutes line |
| %seconds%    | Replaced by sseconds line |
