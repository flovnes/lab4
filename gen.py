import random

surnames = ['Атаманенко', 'Конопленко', 'Атамась', 'Єрмоленко']
firstnames = ['Бодя', 'Саша', 'Софія', 'Ніка']
patronymics = ['Сергійович', 'Романович', 'Степанович', 'Георгійович']
sexes = ['M', 'F', 'Ж', 'Ч']
marks = [1, 2, 3, 4, 5, '-']
scholarships = list(range(1234, 4322))

lines = []
for _ in range(20):
    surname = random.choice(surnames)
    firstname = random.choice(firstnames)
    patronymic = random.choice(patronymics)
    sex = random.choice(sexes)
    date_of_birth = f"{random.randint(1, 28):02d}.{random.randint(1, 12):02d}.{random.randint(1995, 2005)}"
    mark1 = random.choice(marks)
    mark2 = random.choice(marks)
    mark3 = random.choice(marks)
    scholarship = random.choice(scholarships)
    
    line = f"{surname} {firstname} {patronymic} {sex} {date_of_birth} {mark1} {mark2} {mark3} {scholarship}"
    lines.append(line)

with open('input.txt', 'w', encoding='utf-8') as file:
    for line in lines:
        file.write(line + '\n')
