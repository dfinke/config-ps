Add-ConfigItem test 42
Add-ConfigItem Uri (New-Object Uri "http://www.microsoft.com")
Add-ConfigItem data (invoke-RestMethod "http://dougfinke.com/powershellfordevelopers/albums.js")