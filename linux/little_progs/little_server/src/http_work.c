#include "../headers/http_work.h"

bool_t is_correct_request(const char *request)
{
 // there are so many if`s because bad request can break logic in next check-functions
	if (is_normal_request_size(request)) 
		if (is_get_request(request))
			if (is_file_exist(request))
				return true;
			else // is_file_exist
				return false;
		else // is_get_request
			return false;
	else // is_normal_request_size
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
	printf("trying to find file(is_file_exist) :%s\n", filename);
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

char *get_response_filename_unsafe(const char *request, char *out)
{
	const int offset_before_file = 5; // "GET /" = 5 symbols
	int i = -1;

	if (request[offset_before_file] == ' ')
	{
		sprintf(out, "%s", BASE_FILE); // base file
		out[strlen(BASE_FILE)] = '\0';
		return out;
	}
	else
	{
		while( request[offset_before_file + (++i)] != ' ' ) // just read 1 word after /
			out[i] = request[offset_before_file + i];
		out[i] = '\0';
		return out;
	} 
		
}

char *get_response_filename(const char *request, char *out)
{
	if (!is_correct_request(request))
	{
		sprintf(out, ERROR_404_FILE); // 404 response file
		out[strlen(ERROR_404_FILE)] = '\0';
		return out;
	}
	else 
		return get_response_filename_unsafe(request, out);
}

char *make_headers(char *out, const char *request)
{
	if (is_correct_request(request))
		return make_200_headers(request, out);
	else 
		return make_404_headers(out);
}

char *make_404_headers(char *out)
{
	strncat(out, _404_RESPONSE_HEADER, strlen(_404_RESPONSE_HEADER));
	return out;
}

char *make_200_headers(const char *request, char *out)
{
	strncat(out, _200_RESPONSE_HEADER, strlen(_200_RESPONSE_HEADER));
	return out;
}
