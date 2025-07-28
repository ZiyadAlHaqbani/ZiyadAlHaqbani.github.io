import os

dirs = os.listdir("pages")

blog_pages = ""

for dir in dirs:
    blog_pages += f'''\n
        <div class="loc-item gradient-background" data-article-src="pages/{dir}/index.html"
                    onclick="changeArticle(event)">
            <h2>{dir}</h2>
        </div>
    '''


index = ''

with open('template_index.template', 'r') as file:
    index = file.read()
    
index = index.replace('_blog_pages_', blog_pages)

with open('index.html', 'w', encoding='utf-8') as f:
    f.write(index)