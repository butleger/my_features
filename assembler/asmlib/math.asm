format ELF64

public gcd
public fibonacci
public factorial
public rec_factorial


section '.gcd'
; in:
;	rax = number
;	rbx = number(divider)
; out:
;	rax = number(result)
gcd:
	push rdx
	.next_iter:
		cmp rbx, 0 ; if devider = 0
		jle .close
		xor rdx, rdx
		div rbx
		mov rax, rdx ; rax = rax % rbx
		cmp rbx, rax; if rbx > rax then swap them
			jle .rax_bigger 
			push rax
			mov rax, rbx
			pop rbx
		.rax_bigger:
		jmp .next_iter
	.close:
		pop rdx
		ret


section '.fibonacci' executable
; in:
;	rax = number
; out:
;	rax = number
fibonacci:
	push rbx
	push rcx

	mov rbx, 1
	mov rcx, 0
	.next_iter:
		cmp rax, 1; if i == 1 - exit 
		jle .close
		dec rax; if i--
		push rbx; swap rbx and rcx
		add rbx,rcx
		pop rcx
		jmp .next_iter
	.close:
		mov rax, rcx
		pop rcx
		pop rbx
	
		ret


section '.factorial' executable
; in:
;	rax = number
; out:
;	rax = number(result)
factorial:
	push rbx

	mov rbx, rax; 
	mov rax, 1
	.next_iter:
		cmp rbx, 1
		jle .close
		mul rbx; rax = rax * rbx
		dec rbx
		jmp .next_iter
	.close:
		pop rbx
		ret


section '.rec_factorial' executable
; in:
;	rax = number
; out:
;	rax = number
rec_factorial:
	push rbx
	cmp rax, 1; if n == 1
	je .return
	mov rbx, rax
	dec rax
	call rec_factorial
	mul rbx; fact(n) = fact(n - 1) * n
	.return:
		pop rbx
		ret

