
import os
import sys
import subprocess

if __name__=='__main__':

    resultsfile=open('results.txt', 'wt')

    for directory in os.listdir('.'):
        if os.path.isdir(directory):
            cmdline=sys.executable+' test.py'
            rc=subprocess.run(cmdline, cwd=directory)
            try:
                exresfile=open(directory+'/tests/result.txt', 'rt')
                res=exresfile.read()
                exresfile.close()
                resultsfile.write(directory+'\t'+res+'\n')
            except:
                #Result file not found
                resultsfile.write(directory+'\t'+'0\t0\n')
                pass

    resultsfile.close()

