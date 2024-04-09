import re

def clean(code:str) -> str:
    line:str = code
    line = re.sub(r'/\*(.|\n)*?\*/', '', line)
    line = re.sub(r'^.*\busing\b.*$', '', line, flags=re.MULTILINE)
    line = re.sub(r'//.*$', '', line, flags=re.MULTILINE)
    line = re.sub(r'^//.*$', '', line, flags=re.MULTILINE)
    line = re.sub(r'System(?:\.[^.]+)+\.{2,}', '', line)
    #line = re.sub(r'\bint\b', '', line)
    #line = re.sub(r'[^a-zA-Z0-9/s]', ' ', line)
    line = re.sub(r'using(?:\.[\w\d]+)?', '', line)
    #line = re.sub(r'\n{2,}', '\n', line)
    line = re.sub(r'\n{2,}', '\n', line, flags=re.MULTILINE)
    #line = re.sub(r'\n\s*\n', '\n', line, flags=re.MULTILINE)
    line = re.sub(r'^[ \t]+','', line, flags=re.MULTILINE)
    line = re.sub(r' {2,}', ' ', line, flags=re.MULTILINE)
    line = re.sub(r'[{}]', '', line, flags=re.MULTILINE)
    line = re.sub(r'^.*\bclass\b.*$', '', line, flags=re.MULTILINE)
    line = re.sub(r'^.*\bnamespace\b.*$', '', line, flags=re.MULTILINE)
    line = line.strip()
    #line = re.sub(r'^.*\bstatic void Main\b.*$', '', line, flags=re.MULTILINE)
    line = line.replace('\ufeff','')

    splitted_line = "\n".join([l for l in line.split("\n") if l.strip()])
    return splitted_line