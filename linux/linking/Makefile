CC=gcc
SRC=main.c
SRC_LIBS=libhello.c
EXEC_NAME=main
BASE_LIB_NAME=hello
CC_FLAGS=-L. -l$(BASE_LIB_NAME)
LIB_FLAGS=-shared -fPIC
HEADERS=hello.h

all: libs main.c
	$(CC) $(SRC) -o $(EXEC_NAME) $(CC_FLAGS)
libs: $(SRC_LIBS) $(HEADERS)
	$(CC) $(LIB_FLAGS) $(SRC_LIBS) -o lib$(BASE_LIB_NAME).so
 
clean:
	@rm $(EXEC_NAME) *.so *.o
