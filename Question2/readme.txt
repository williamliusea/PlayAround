Each time a visitor requests a page from our website, our webserver writes a log entry recoding the visitor's identity and the kind of page requested. Entries are written in chronological order to a plain-text file, with one entry per line. The format of each entry is:

user-id page-type-id

User IDs are arbitrary strings that uniquely represent a given user; if a user visits multiple pages, each log entry will have the same user ID. Page type IDs are arbitrary strings that uniquely represent a given kind of page on our site, such as the homepage, a product detail pages, or the shopping cart. Tons of users visit our website, but there are only a few dozen types of pages.

We can use our weblogs to answer questions about user behavior. One interesting question is: what is the most common three page sequence through the site? E.g., if the most common pattern is to buy items advertised on the home page of the site, we might see the most common three page sequence as "Homepage -> ProductDetailPage -> ShoppingCart". However, if customers spend a lot of time browsing the "Customers who bought this item also bought" feature, we might see the most common three page sequence as "ProductDetailPage -> ProductDetailPage -> ProductDetailPage".

Attached is a sample log file for your reference. Within the first 10 lines of the sample, customer "234" travels through the sequences "Listmania -> ProductDetail -> Checkout" and "ProductDetail -> Checkout -> HomePage" once each.

For the sake of this test feel free to assume that everything will fit in memory. Do keep in mind that given the size of our data sets, performance has to be considered, also, we will be looking at more than just correct output..
