.PHONY: all clean build link
CC=gcc
CC_FLAGS=-O3
LD=gcc
LD_FLAGS=
SRC=web-server.c
OBJECTS_SRC=$(addsuffix .o,$(basename $(SRC)))
EXEC_NAME=server


all: build link

link: $(OBJECTS_SRC)
	@$(LD) $(LD_FLAGS) $^ -o $(EXEC_NAME)
build: $(OBJECTS_SRC)

%.o: %.c
	@$(CC) $(CC_FLAGS) -c $^

clean:
	@rm $(OBJECTS_SRC) $(EXEC_NAME)
