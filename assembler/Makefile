CC=fasm
CFLAGS= $()
DELETE= rm -rf
LD = ld 
LDFLAGS = -o
LIB = asmlib
SRC = main.asm $(LIB)/math.asm $(LIB)/io.asm $(LIB)/sys.asm $(LIB)/str.asm $(LIB)/algo.asm
SRC_SUFF = asm
EXEC_NAME = main


all: link
	@./$(EXEC_NAME)

link: $(addsuffix .o, $(basename $(SRC))) 
	@$(LD) $^ $(LDFLAGS) $(EXEC_NAME)

%.o: %.$(SRC_SUFF)
	@$(CC) $(CFLAGS) $^

clean:
	@$(DELETE) *.o $(EXEC_NAME)
