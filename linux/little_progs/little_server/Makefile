.PHONY: all clean build link
CC=gcc
CC_FLAGS= -Wall -O3 -g
LD=gcc
LD_FLAGS=
SRC=main.c http_work.c socket_work.c
HEADERS=http_work.h socket_work.h config_def.h
OBJECTS_SRC=$(addprefix $(OBJ_DIR)/,$(addsuffix .o,$(basename $(SRC))))
EXEC_NAME=server
OBJ_DIR=obj


all: build link

link: $(OBJECTS_SRC)
	@$(LD) $(LD_FLAGS) $^ -o $(EXEC_NAME)

build: $(OBJECTS_SRC)

$(OBJ_DIR)/%.o: %.c
	@$(CC) $(CC_FLAGS) -c $^
	@mv $(addsuffix .o,$(basename $^)) $@

clean:
	@rm $(OBJECTS_SRC) $(EXEC_NAME)
