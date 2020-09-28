format ELF64 
public _start

include "asmlib/io.inc"
include "asmlib/sys.inc"
include "asmlib/str.inc"
include "asmlib/algo.inc"
include "asmlib/math.inc"

section '.bss' writable
buffer_size equ 21
buffer db buffer_size

section '.text' executable
_start:
	mov rax, buffer
	mov rbx, buffer_size 
	call input_number
	call rec_factorial
	call print_number
	call exit
