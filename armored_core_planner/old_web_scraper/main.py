
import scrapy
from scrapy.crawler import CrawlerProcess
from web_scraper import MultiSiteSpider
from models.mechs_holder import mechs_holder

# Holds the colllection of main models for each of the games
mech_holder = mechs_holder()

# Create a CrawlerProcess instance
process = CrawlerProcess(settings={
      'FEEDS': {
        'output.json': {
            'format': 'json',
            'encoding': 'utf-8',
            'store_empty': False,
        },
    },
    'DOWNLOAD_DELAY': 2,  # Delay between requests
    'CONCURRENT_REQUESTS': 16,  # Max concurrent requests
    'CONCURRENT_REQUESTS_PER_DOMAIN': 8,  # Max concurrent requests per domain
    'AUTOTHROTTLE_ENABLED': True,  # Enable autothrottling
    'AUTOTHROTTLE_START_DELAY': 1,  # Starting delay
    'AUTOTHROTTLE_MAX_DELAY': 10,  # Max delay
    'RETRY_ENABLED': True,  # Enable retries
    'RETRY_TIMES': 3,  # Retry failed requests 3 times
    'LOG_LEVEL': 'INFO',  # Set log level
    #'USER_AGENT': 'MyCustomScraperBot/1.0 (+http://www.example.com)',  # Custom user-agent
    'COOKIES_ENABLED': False,  # Disable cookies
    'DEPTH_LIMIT': 3,  # Limit crawl depth to 3
    'DOWNLOAD_TIMEOUT': 15,  # Timeout for requests
})

# Start the spider by passing the spider class to the process
process.crawl(MultiSiteSpider)

# Start the crawling process
process.start()
