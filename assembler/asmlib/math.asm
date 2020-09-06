format ELF64

public gcd
public fibonacci
public factorial


section '.gcd'
;|input:
;rax:number
;rbx:number(divider)
;|output:
;rax:number(result)

gcd:
	push rdx
	.next_iter:
		cmp rbx, 0
		jle .close
		xor rdx, rdx
		div rbx
		mov rax, rdx
		cmp rbx, rax
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
;|input:
;	rax:number
;|output:
;	rax:number
fibonacci:
	push rbx
	push rcx

	mov rbx, 1
	mov rcx, 0
	.next_iter:
		cmp rax, 1
		jle .close
		dec rax
		push rbx
		add rbx,rcx
		pop rcx
		jmp .next_iter
	.close:
		mov rax, rcx
		pop rcx
		pop rbx
	
		ret


section '.factorial' executable
;|input
;	rax:number
;|output
;	rax:number(result)
factorial:
	push rbx

	mov rbx, rax
	mov rax, 1
	.next_iter:
		cmp rbx, 1
		jle .close
		mul rbx
		dec rbx
		jmp .next_iter
	.close:
	pop rbx
	ret
