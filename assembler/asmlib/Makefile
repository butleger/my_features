DELETE=rm
CC = fasm
SRC = algo.asm io.asm math.asm str.asm sys.asm

all: $(addsuffix .o, $(basename $(SRC)))

%.o: %.asm
	@$(CC) $^	
clean: 
	@$(DELETE) *.o
