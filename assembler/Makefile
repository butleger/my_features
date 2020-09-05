CC=fasm
CFLAGS= $()
DELETE= rm -rf
LD = ld 
LDFLAGS = -o
SRC = main.asm
SRC_SUFF = asm
EXEC_NAME = main


all: link
	./$(EXEC_NAME)

link: $(addsuffix .o, $(basename $(SRC))) 
	$(LD) $^ $(LDFLAGS) $(EXEC_NAME)

%.o: %.$(SRC_SUFF)
	$(CC) $(CFLAGS) $^

clean:
	$(DELETE) *.o $(EXEC_NAME)
