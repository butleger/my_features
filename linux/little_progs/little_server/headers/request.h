#ifndef REQUEST_H
#define REQUEST_H 


struct request;
struct request* parse_request(const char *request, struct request out);


#endif // REQUEST_H