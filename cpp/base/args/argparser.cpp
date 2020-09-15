#include "argparser.h"

ArgParser::ArgParser(const char **args, size_t argcount)
{
    this->argsValues = new string[argcount];
    for (size_t i = 0 ; i < argcount ; ++i )
        argsValues[i] = args[i];
}

ArgParser::~ArgParser()
{
    delete[] this->argsValues;
}
