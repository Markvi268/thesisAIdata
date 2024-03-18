# -*- coding: utf-8 -*-
import sys
import subprocess
import re
import os
import shutil
import glob

def getpath() -> str:
    # Find path to current root
    pathlist = split(sys.argv[0])
    if len(pathlist) == 1:
        path = './'
    else:
        path = pathlist[0] + '/'

    return path



#Load student code
def loadmycode(codefile:str='src/my_code.py'):
    for encoding in ['latin1', 'utf8','utf16','cp437']:
        try:
            with open(codefile, encoding=encoding) as f:
                my_code = f.read()
            return my_code
        except:
            pass


def load_python_code():
    file_name=getpath()+'/src/my_code.py'
    with open(file_name) as f:
        contents = f.read()
        return contents
    
def dotNetProjectName() -> str:
    project_files=glob.glob('*.csproj')
    project_file=project_files[0]
    return os.path.splitext(project_file)[0]


def dotNetNumbersFormat() -> tuple[str, str]:
    path=getpath()+'/../helpers'
    project_name='environment'

    tmp_directories=['bin', 'obj']
    for d in tmp_directories:
        try:
            shutil.rmtree(path+'/'+d)
        except:
            pass

    timeout=10
        
    try:
        rc = subprocess.run(['dotnet', 'build'], cwd=path, shell=True)
        if rc.returncode!=0:
            raise FileNotFoundError
    except:
        print('!!Compile falled to fallback!!')
        rc = subprocess.run(['dotnet build'], cwd=path, shell=True)
        print("Fallback completed, don't worry")

    try:
        cmd_line=[path+'/bin/Debug/net6.0/'+project_name+'.exe',]
        rc = subprocess.run(cmd_line, cwd=path, stdout=subprocess.PIPE, text=True, timeout=timeout)
    except:
        print('!!Running falled to fallback!!')
        cmd_line=[path+'/bin/Debug/net6.0/'+project_name,]
        rc = subprocess.run(cmd_line, stdout=subprocess.PIPE, text=True, timeout=timeout)
        print("Fallback completed, don't worry")

    neg=rc.stdout[0]
    sep=rc.stdout[2]
    return neg, sep


def callDotNet(cmdline_args:list[str]=[], input:str='', timeout:int=30, build:bool=True) -> str:
    path=getpath()
    project_name=dotNetProjectName()

    tmp_directories=['bin', 'obj']
    if build:
        for d in tmp_directories:
            try:
                shutil.rmtree(d)
            except:
                pass
    if build:
        try:
            rc = subprocess.run(['dotnet', 'build'], cwd=path, shell=True)
            if rc.returncode!=0:
                raise FileNotFoundError
        except:
            print('!!Compile falled to fallback!!')
            rc = subprocess.run(['dotnet build'], cwd=path, shell=True)
            print("Fallback completed, don't worry")

    try:
        cmd_line=['bin/Debug/net6.0/'+project_name+'.exe',]+cmdline_args
        rc = subprocess.run(cmd_line, cwd=path+'/src', stdout=subprocess.PIPE, text=True, input=input, timeout=timeout)
    except:
        print('!!Running falled to fallback!!')
        cmd_line=['../bin/Debug/net6.0/'+project_name,]+cmdline_args
        rc = subprocess.run(cmd_line, cwd=path+'/src', stdout=subprocess.PIPE, text=True, input=input, timeout=timeout)
        print("Fallback completed, don't worry")

    return rc.stdout

def callDotNetFunction(cmdline_args:list[str]=[], input:str='', timeout:int=30, build:bool=True) -> str:
    path=getpath()
    project_name=dotNetProjectName()

    tmp_directories=['bin', 'obj']
    if build:
        for d in tmp_directories:
            try:
                shutil.rmtree(d)
            except:
                pass

    #shutil.copy2('tests/testmain.cs', 'src/testmain.cs')
    #shutil.copy2('tests/my_code.csproj', 'src/my_code.csproj')
    #Compile the source code
    if build:


        if os.path.exists('tests/testmain.cs.hidden'):
            shutil.copyfile('tests/testmain.cs.hidden', 'tests/testmain.cs')
        try:
            rc = subprocess.run(['dotnet', 'build'], cwd=path, shell=True)
            if rc.returncode!=0:
                raise FileNotFoundError
        except:
            print('!!Compile falled to fallback!!')
            rc = subprocess.run(['dotnet build'], cwd=path, shell=True)
            print("Fallback completed, don't worry")
        finally:
            if os.path.exists('tests/testmain.cs.hidden'):
                os.remove('tests/testmain.cs')


    try:
        cmd_line=['bin/Debug/net6.0/'+project_name+'.exe',]+cmdline_args
        rc = subprocess.run(cmd_line, cwd=path+'/src', stdout=subprocess.PIPE, text=True, input=input, timeout=timeout)
    except:
        print('!!Running falled to fallback!!')
        cmd_line=['../bin/Debug/net6.0/'+project_name,]+cmdline_args
        rc = subprocess.run(cmd_line, cwd=path+'/src', stdout=subprocess.PIPE, text=True, input=input, timeout=timeout)
        print("Fallback completed, don't worry")

    return rc.stdout



def split(s:str='') -> list[str]:
    return re.split('/|\\\\', s)
