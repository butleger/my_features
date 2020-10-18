format ELF64

public exit
public fcreate
public fdelete
public fseek
public fopen
public fclose
public fwrite
public fread

include "macro.m"
include "io.inc"

section '.data' executable
	filename db 'test_file.txt', 0


section '.fcreate' executable
; in:
;	rax = filename
;	rbx = permissions
; out:
;	rax = descriptor
fcreate:
	push rcx
	push rbx

	mov rcx, rbx
	mov rbx, rax
	mov rax, 8; syscall of create
	int 0x80
	
	pop rbx
	pop rcx
	ret	


section '.fdelete' executable
; in:
;	rax = filename
fdelete:
	push rbx
	mov rax, 10; unlink syscall
	mov rbx, rax
	int 0x80
	pop rbx
	ret


section '.fopen' executable
; in:
;	rax = filename
;	rbx = MODE(O_RDONLY = 0, O_WRONLY = 1, O_RDWR = 2)
; out:
;	rax = descriptor
fopen:
	push rbx
	push rcx

	mov rcx, rbx
	mov rbx, rax
	mov rax, 5; open syscall
	int 0x80
	
	pop rcx
	pop rbx
	ret


section '.fclose' executable
; in:
;	rax = descriptor
fclose:
	push rbx
	mov rax, 6; close syscall
	mov rbx, rax
	int 0x80
	pop rbx
	ret


section '.fwrite' executable
; in:
;	rax = descriptor
;	rbx = data
;	rcx = size of data
fwrite:
	push_abcd
	
	push rbx
	push rcx

	mov rbx, 1 
	xor rcx, rcx
	call fseek

	pop rcx
	pop rbx

	mov rdx, rcx
	mov rcx, rbx
	mov rbx, rax
	mov rax, 4; write syscall
	call print_abcd
	int 0x80

	pop_dcba
	ret


section '.fread' executable
; in:
;	rax = descriptor
;	rbx = buffer
;	rcx = size of buffer
fread:
	push_abcd
	
	push rbx
	push rcx

	mov rbx, 1 
	xor rcx, rcx
	call fseek

	pop rcx
	pop rbx

	mov rdx, rcx
	mov rcx, rbx
	mov rbx, rax
	mov rax, 3; write syscall
	int 0x80

	pop_dcba
	ret


section '.fseek' executable
; in:
;	rax = descriptor
;	rbx = MODE_SEEK(
;		SEEK_SET = 0 - offset from start of file
;		SEEK_CUR = 1 - offset from current position
;		SEEK_END = 2 - offset from end of file?
fseek:
	push rax
	push rbx
	push rdx

	mov rcx, rbx
	mov rbx, rax
	mov rax, 19
	int 0x80

	pop rdx
	pop rbx
	pop rdx
	ret


section '.exit' executable
exit :
	mov rax, 1
	mov rbx, 0
	int 0x80
