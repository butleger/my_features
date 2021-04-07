.PHONY: all lib clean
DELETE=rm
CC = fasm
LD = ld
LD_FLAGS = 
LIB_BASENAME = core
LIB_NAME = lib$(LIB_BASENAME).so
SRC = algo.asm io.asm math.asm str.asm sys.asm
SRC_OBJ = $(addsuffix .o,$(basename $(SRC))) # just change extensions from .asm to .o
 

all: $(SRC_OBJ)

lib: all 
	@$(LD) $(SRC_OBJ) -shared -o $(LIB_NAME)
%.o: %.asm
	@$(CC) $^	
clean: 
	@$(DELETE) $(SRC_OBJ)
