.PHONY: main all link libs clean
CC=fasm
CFLAGS= $()
DELETE= rm -rf
LD = ld 
LDFLAGS = -o
LIB_PATH = asmlib # path to libs
MAIN_FILE = main.asm
EXEC_NAME = $(basename $(MAIN_FILE)) # remove extension from MAIN_FILE
LIBS = $(addprefix $(LIB_PATH)/, math.asm io.asm sys.asm str.asm algo.asm)


all: link # run main file
	@./$(EXEC_NAME)

link: main libs 
	@$(LD) $(addsuffix .o, $(basename $(LIBS) $(MAIN_FILE))) $(LDFLAGS) $(EXEC_NAME)

main: $(MAIN_FILE)
	@$(CC) $(CFLAGS) $(MAIN_FILE)

libs: # use libs own Makefile
	@make -C $(LIB_PATH)

clean:
	@$(DELETE) *.o $(EXEC_NAME)
	@make clean -C $(LIB_PATH)# use libs own make clean
