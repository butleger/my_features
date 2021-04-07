CC=gcc
CC_FLAGS=-o3
LD=gcc
SRC=main.c sub_process.c
EXEC_NAME=main
EXEC_SUB_NAME=sub_process


all: $(EXEC_NAME) $(EXEC_SUB_NAME)

$(EXEC_NAME): $(addsuffix .o, $(EXEC_NAME))
	@$(CC) $(CC_FLAGS) $^ -o $(EXEC_NAME)
$(EXEC_SUB_NAME):  $(addsuffix .o, $(EXEC_SUB_NAME))
	@$(CC) $(CC_FLAGS) $^ -o $(EXEC_SUB_NAME) 
%.o: %.c
	@$(CC) -c $^
clean:
	rm -rf *.o $(EXEC_NAME) $(EXEC_SUB_NAME)
