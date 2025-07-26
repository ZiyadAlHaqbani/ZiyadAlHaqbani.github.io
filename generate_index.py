import os

dirs = os.listdir("pages")

blog_pages = ""

for dir in dirs:
    blog_pages += f'''\n
        <h2><a href="pages/{dir}/index.html">{dir}</a></h2>
    '''


index =f'''
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <title>Ziyad AlHaqbani's blog</title>
    <link rel="stylesheet" href="index.css">
</head>

<body>
    <header>
        <h1>Ziyad AlHaqbani's blog</h1>
        <h2>
            Description:
        </h2>
        
        <h3>
            This blog will contain random topics about programming that
            i happen to be interested in at the moment.
        </h3>
    </header>
</body>
{blog_pages}

</html>
'''

with open('index.html', 'w', encoding='utf-8') as f:
    f.write(index)