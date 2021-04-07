.PHONY: all clean
CC=gcc
CC_FLAGS=-O3
LD=gcc
SRC=demon.c
EXEC_NAME=demon
LOG_FILE=log


all: link
	@./$(EXEC_NAME) $(LOG_FILE)
	@echo "log file:"
	@cat $(LOG_FILE)

link: $(addsuffix .o, $(basename $(SRC)))
	@$(LD) $(LD_FLAGS) -o $(EXEC_NAME) $^
%.o: %.c
	@$(CC) $(CC_FLAGS) -c $^
clean:
	@rm -rd *.o $(EXEC_NAME)
	@echo "" > $(LOG_FILE)	
