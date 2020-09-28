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
	call dw_rand
	call print_number
	call endl
	call dw_rand
	call print_number
	call endl
	call dw_rand
	call print_number
	call endl
	call exit
