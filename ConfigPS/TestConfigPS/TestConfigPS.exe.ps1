Add-ConfigItem count 123
Add-ConfigItem uri ([uri]"http://dougfinke.com/blog")

1..50 | % {Add-ConfigItem "Item$($PSItem)" $PSItem}

Add-ConfigItem processes (ps  | Where handles -gt 700)     # 
Add-ConfigItem services  (gsv | Where status -match 'run') #

Add-ConfigItem json (Invoke-RestMethod www.whitehouse.gov/facts/json).url_title