
import scrapy
from parsers.ac1.ac1_parser import parse_ac1

class MultiSiteSpider(scrapy.Spider):
    name = "multi_site_spider"

    def start_requests(self):
        # You can fetch websites from an external file, database, or generate them programmatically.
        websites = {
            'https://armoredcore.fandom.com/wiki/List_of_First_Generation_Parts': parse_ac1,
        }
        for url, parse_func in websites.items():
            yield scrapy.Request(url=url, callback=parse_func)

    def parse(self, response):
        # General parsing logic that works across sites
        page_title = response.css('title::text').get()
        print(f"Page title: {page_title}")
        # Further handling for common or different page structures
