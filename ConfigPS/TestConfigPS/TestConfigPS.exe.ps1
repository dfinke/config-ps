Add-ConfigItem count 123
Add-ConfigItem uri ([uri]"http://dougfinke.com/blog")

1..6 | % {Add-ConfigItem "Item$($PSItem)" $PSItem}

Add-ConfigItem processes (ps  | Where handles -gt 700)     # 
Add-ConfigItem services  (gsv | Where status -match 'run') #