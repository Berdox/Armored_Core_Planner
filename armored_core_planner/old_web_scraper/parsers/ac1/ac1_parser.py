
from ../../models\ac1\ac1_mech_model

ac1_mech = ac1_mech_model()

def parse_ac1(response):
    #page_title = response.css('title::text').get()
    #print(f"Page title: {page_title}")
    #print("hello world")
    tbody_tags = response.xpath('//tbody')

    # Loop through each <tbody> tag
    for index, tbody in enumerate(tbody_tags):
        # Process the first tbody differently (if it has 14 columns)
        if index == 0:
            parse_ac1_head(tbody)
        elif index == 1:
            parse_ac1_pp_head(tbody)
            

def parse_ac1_head(tbody):
    rows = tbody.xpath('.//tr')
    for row in rows:
        part_id = row.xpath('td[1]//text()').get().strip()
        # Extract other data for tbody 1
        
def parse_ac1_pp_head(tbody):
    rows = tbody.xpath('.//tr')
    for row in rows:
        part_id = row.xpath('td[1]//text()').get().strip()
        # Extract other data for tbody 1