.PHONY: all clean
CC=gcc
CC_FLAGS=-O3
LD=gcc
SRC=demon.c
EXEC_NAME=demon

all: $(addsuffix .o, $(basename $(SRC)))
	@$(LD) $(LD_FLAGS) -o $(EXEC_NAME) $^
%.o: %.c
	@$(CC) $(CC_FLAGS) -c $^
clean:
	@rm -rd *.o $(EXEC_NAME)
	@echo "" > log	
