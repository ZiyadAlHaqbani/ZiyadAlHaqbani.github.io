import os

dirs = os.listdir("pages")

blog_pages = ""

for dir in dirs:
    blog_pages += f'''\n
    <a href="pages/{dir}/{dir}.html">
        <main>
            <article>
                <h2>
                    {dir}
                </h2>
            </article>
        </main>
    </a>
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

        <pre class="literal">
            This blog will contain random topics about programming that
            i happen to be interested in at the moment.
        </pre>
    </header>
</body>
{blog_pages}

</html>
'''

with open('index.html', 'w', encoding='utf-8') as f:
    f.write(index)