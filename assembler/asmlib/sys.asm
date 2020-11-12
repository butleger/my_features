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
include "const.m"

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
	mov rax, CREAT_INT_X32_NUM; syscall of create
	_make32_syscall
	
	pop rbx
	pop rcx
	ret	


section '.fdelete' executable
; in:
;	rax = filename
fdelete:
	push rbx
	mov rax, UNLINK_INT_X32_NUM; unlink syscall
	mov rbx, rax
	_make32_syscall
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
	mov rax, OPEN_INT_X32_NUM; open syscall
	_make32_syscall
	
	pop rcx
	pop rbx
	ret


section '.fclose' executable
; in:
;	rax = descriptor
fclose:
	push rbx
	mov rax, CLOSE_INT_X32_NUM; close syscall
	mov rbx, rax
	_make32_syscall
	pop rbx
	ret


section '.fwrite' executable
; in:
;	rax = descriptor
;	rbx = data
;	rcx = size of data
fwrite:
	push_abcd

	mov rdx, rcx
	mov rcx, rbx
	mov rbx, rax
	mov rax, WRITE_INT_X32_NUM; write syscall
	_make32_syscall

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
	mov rax, READ_INT_X32_NUM; read syscall
	_make32_syscall

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
	mov rax, LSEEK_INT_X32_NUM
	_make32_syscall

	pop rdx
	pop rbx
	pop rdx
	ret


section '.exit' executable
exit :
	mov rax, EXIT_INT_X32_NUM
	mov rbx, GOOD_EXIT ; 0
	_make32_syscall
