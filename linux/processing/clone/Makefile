CC=gcc
LD=gcc
SRC=main.c
EXEC_NAME=main
CC_FLAGS=-o3


all: $(addsuffix .o, $(basename $(SRC)))
	$(CC) $(CC_FLAGS) -o $(EXEC_NAME) $^
%.o: %.c
	$(CC) -c $(CC_FLAGS) $^
clean:
	rm -rf *.o $(EXEC_NAME)
