#include "../headers/http_work.h"

/*
 * _200_RESPONSE_HEADER, _404_RESPONSE_HEADER you can find in http_work.h 
 * also so many get functions used to make program more extensive
 */

char *make_headers(char *out, const char *request)
{
	if (is_correct_request(request))
		return make_200_headers(request, out);
	else 
		return make_404_headers(request, out);
}

char *make_404_headers(const char* request, char *out)
{
	char *_404_response_headers;

	_404_response_headers = get_404_response_header();
	strncat(out, _404_response_headers, strlen(_404_response_headers)); 
	return out;
}

char *get_404_response_header()
{
	return _404_RESPONSE_HEADER;
}

char *make_200_headers(const char *request, char *out)
{
	char *_200_response_headers;

	_200_response_headers = get_200_response_header();
	strncat(out, 200_response_headers, strlen(_200_response_headers));
	return out;
}

char *get_200_response_header()
{
	return _200_RESPONSE_HEADER;
}

bool_t is_correct_request(const char *request)
{
 // there are so many if`s because bad request can break logic in next check-functions
	if (is_normal_request_size(request)) 
		if (is_get_request(request))
			if (is_file_exist(request))
				return true;
			else // file not exist
				return false;
		else // not a get request
			return false;
	else // not a normal request size
		return false;  
}

bool_t is_normal_request_size(const char *request)
{
	if (strlen(request) < MIN_HEADER_SIZE)
		return false;
	else 
		return true;
}

bool_t is_get_request(const char *request)
{
	if (strncmp(request, "GET", 3) == 0)
		return true;
	else 
		return false;
}

bool_t is_file_exist(const char *request)
{
	DIR *www_dir = opendir(DIR_ROOT);
	struct dirent *file;
	char filename[50];

	get_response_filename_unsafe(request, filename);
	if (www_dir == 0)
		return false;
	else
	{
		file = readdir(www_dir);
		while (file != NULL)
		{
			if ( strcmp(file->d_name, filename) == 0 )
				return true;
			file = readdir(www_dir);
		}
	}
	return false;
}

int get_size_of_file(const char *filename)
{
	struct stat file_stat;
	if ( stat(filename, &file_stat) < 0 )
		return -1;
	else 
		return file_stat.st_size;
}

char *get_response_filename(const char *request, char *out)
{
	char *error_404_filename;

	error_404_filename = get_error_404_filename();
	if (!is_correct_request(request))
	{
		sprintf(out, error_404_filename); // 404 response file
		out[strlen(error_404_filename)] = '\0';
		return out;
	}
	else 
		return get_response_filename_unsafe(request, out);
}

char *get_error_404_filename()
{
	return ERROR_404_FILENAME;
}

char *get_response_filename_unsafe(const char *request, char *out)
{
	char *base_filename;
	int offset_before_file = 5; // "GET /" = 5 symbols
	int i = -1;

	base_filename = get_base_filename();
	if (request[offset_before_file] == ' ')
	{
		sprintf(out, "%s", base_filename); // base file
		out[strlen(base_filename)] = '\0';
		return out;
	}
	else
	{
		while( request[ offset_before_file + (++i) ] != ' ' ) // just read 1 word after /
			out[i] = request[offset_before_file + i];
		out[i] = '\0';
		return out;
	} 
}

char *get_base_filename()
{
	return BASE_FILENAME;
}
