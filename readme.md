# DevHelper

###Usage

Delete all [bin], [obj] and [package] folders recursively.

    devhelper -c "c:\work\tools"

Touch the write, creation and access dates for all files and folders recursively (to current date/time).

    devhelper -t "c:\work\tools"

Zip a folder

    devhelper --zf "c:\work\tools.zip" --zd "c:\work\tools"

or any combination

    devhelper -c "c:\work\tools" -t "c:\work\tools" --zf "c:\work\tools.zip" --zd "c:\work\tools"

###References
* [Command Line Parser Library](https://github.com/cosmo0/commandline)
