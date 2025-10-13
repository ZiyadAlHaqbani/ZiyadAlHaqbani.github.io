import os
from datetime import datetime, timezone

dirs = os.listdir("pages")

blog_pages = ""

counter = 0

dirs.sort(reverse=True)
for dir in dirs:
    page_name = dir.replace('_', ' ')
    blog_pages += f'''\n
        <div class="loc-item-outer">
                    <div id="button_{counter}" class="loc-item" data-article-src="pages/{dir}/index.html"
                        onclick="changeArticle(event)">
                        <div class="loc-item-inner">
                            {page_name}
                        </div>
                    </div>
                </div>
    '''
    counter += 1


index = ''

with open('template_index.template', 'r') as file:
    index = file.read()

index = index.replace('_blog_pages_', blog_pages)

timestamp = datetime.now(timezone.utc).strftime("%B %d, %Y at %H:%M UTC")
timeStampHTML = f'<h3>Last generated: {timestamp}</h3>'
index = index.replace('_time_stamp_', timeStampHTML)

with open('index.html', 'w', encoding='utf-8') as f:
    f.write(index)