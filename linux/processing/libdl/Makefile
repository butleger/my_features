CC=gcc
CC_FLAGS=-fPIC -ldl
SRC=main.c
LIB_FLAGS=-fPIC -shared
LIBS_SRC=hello.c
LIBS_HEADERS=hello.h
EXEC_LIB_BASENAME = Hello
EXEC_NAME=hello


all: compile lib

compile: hello.h main.c lib
	$(CC) $(SRC) -o $(EXEC_NAME) $(CC_FLAGS)
lib: $(LIBS_SRC) $(LIBS_HEADERS)
	$(CC) $(LIBS_SRC) -o lib$(EXEC_LIB_BASENAME).so $(LIB_FLAGS)
clean:
	rm $(EXEC_NAME) lib$(EXEC_LIB_BASENAME).so > /dev/null
