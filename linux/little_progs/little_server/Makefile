.PHONY: all clean build link
CC=gcc
CC_FLAGS= -Wall -O3 -g
LD=gcc
LD_FLAGS=
SRC_DIR=src
OBJ_DIR=obj
HEADERS_DIR=headers
SRC=$(addprefix $(SRC_DIR)/,main.c http_work.c socket_work.c) # making all like %SRC_DIR%/<name>.c
OBJ_SRC=$(addprefix $(OBJ_DIR)/,$(addsuffix .o,$(basename $(notdir $(SRC))))) # making all like <name>.o
HEADERS=$(addprefix $(HEADERS_DIR)/,http_work.h socket_work.h config_def.h) # making all like %HEADERS_DIR%/<name>.h
EXEC_NAME=server


all: build link

link: $(OBJ_SRC)
	@$(LD) $(LD_FLAGS) $^ -o $(EXEC_NAME)

build: $(OBJECTS_SRC)

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.c # this shit in the goal just change object name for $(OBJ_DIR)/%.o
	@$(CC) $(CC_FLAGS) -c $^
	@mv $(notdir $@) $@ # first shit rename %OBJ_DIR%/<name>.o into %SRC_DIR%/<name>.o 


clean:
	@rm $(OBJ_SRC) $(EXEC_NAME)
