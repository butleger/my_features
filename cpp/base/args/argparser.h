#ifndef ARGPARSER_H
#define ARGPARSER_H

#include <string>

class ArgParser
{
	public :
		ArgParser(const char ** args, size_t argcount);
                ~ArgParser();
	private:
                std::string* argsValues;
		
};

#endif
