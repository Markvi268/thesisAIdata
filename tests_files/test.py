
import sys
import unittest
import os
import re

if __name__=='__main__':

    def split(s:str) -> list[str]:
        return re.split('/|\\\\', s)

    #Find path to current root
    pathlist=split(sys.argv[0])
    if len(pathlist)==1:
        path='./'
    else:
        path=pathlist[0]+'/'
    testpath=path+'tests'

    resultfile=testpath+'/result.txt'
    try:
        os.remove(resultfile)
    except:
        pass

    sys.path.insert(0, testpath)
    sys.path.insert(0, path+'src')
 
    from tests_files.hyppy.tests import *

    curr_file=os.path.abspath(__file__)
    exname = split(curr_file)[-2]

    print('Test', exname)

    unittest.main(verbosity=2, exit=False)

    outputfile=open(resultfile, 'wt')
    outputfile.write('{0}\t{1}'.format(completed(), started()))
    outputfile.close()
    if started()>completed():
        print(started()-completed(), '/', started(), 'tests failed!')
    else:
        print(completed(),'tests completed succesfully')


