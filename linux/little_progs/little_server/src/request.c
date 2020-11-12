#include "../config_def.h"

// warning this struct will contain pointers to parts of request
// and this shit will not allocate any memory in request struct by itself
struct request
{

	char *request_type; // GET, POST or others
	char *domain; // also name of folder where site should be
	char *file;
	char **headers; // all headers in array of string
}

struct request get_request(const char *request)
{
	
}