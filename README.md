Drexyia.Yaml.Configuration
==========================

Drexyia.Yaml.Configuration is a library to allow you to use yaml configuration files instead of the standard xml configuration file. 

appSettings is a simple keyValue pair dictionary, the standard .net configuration system stores this data in xml. To me this seems an overly verbose way to store this information. 

In the below xml most of the text is cruft and the vital key value information is hidden away within it.


```
<appSettings>
		<add key="key1" value="value1"/>
		<add key="key2" value="value2"/>
</appSettings>	
```

This library allows you to use Yaml to store the appSettings information making for a cleaner way to view your key value information. The library uses the following yaml to store appSettings

```
app-settings:
  key1: 'value1'
  key2: 'value2'
```

## Contributing

Use Unix (LF) line endings not windows (CR+LF), search and replace with regular expressions \r\n (CR+LF) windows \n   (LF) unix.

set git config --global core.autocrlf false to stop git auto fomatting line endings

Use spaces instead of tabs regular expression search \t

## Contributors

Here's a [list](https://github.com/drexyia/WsdlUI/contributors) of all the people who have contributed to the
development of WsdlUI.

## Bugs & Improvements

Bug reports and suggestions for improvements are always welcome.
