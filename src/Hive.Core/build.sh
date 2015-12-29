#!/bin/bash
SCRIPT_PATH="${BASH_SOURCE[0]}";
if ([ -h "${SCRIPT_PATH}" ]) then
  while([ -h "${SCRIPT_PATH}" ]) do SCRIPT_PATH=`readlink "${SCRIPT_PATH}"`; done
fi
pushd . > /dev/null
cd `dirname ${SCRIPT_PATH}` > /dev/null
SCRIPT_PATH=`pwd`;
popd  > /dev/null

if ! [ -f $SCRIPT_PATH/tools/.nuget/nuget.exe ] 
    then
        wget "https://www.nuget.org/nuget.exe" -P $SCRIPT_PATH/tools/.nuget/
fi

mono $SCRIPT_PATH/tools/.nuget/nuget.exe update -self
mono $SCRIPT_PATH/tools/.nuget/nuget.exe install Cake -OutputDirectory $SCRIPT_PATH/tools/ -ExcludeVersion
mono $SCRIPT_PATH/tools/.nuget/nuget.exe install xunit.runner.console -OutputDirectory tools -ExcludeVersion

export encoding=utf-8

mono $SCRIPT_PATH/tools/Cake/Cake.exe $SCRIPT_PATH/build.cake "$@"