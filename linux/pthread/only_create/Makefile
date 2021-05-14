CC = gcc
CC_FLAGS = -Wall 
LD = gcc
LD_FLAGS = -pthread
SRC = main.c
OBJ = $(addsuffix .o, $(basename $(SRC)))
EXEC_NAME = result



all: $(EXEC_NAME)
	./$(EXEC_NAME)

$(EXEC_NAME): $(OBJ)
	$(LD) $(LD_FLAGS) $(OBJ) -o $(EXEC_NAME)

$(OBJ): $(SRC)
	$(CC) $(CC_FLAGS) -c $(SRC)
 
clean:
	rm -r $(OBJ) $(EXEC_NAME)

