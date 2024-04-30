import random

surnames = ['Атаманенко', 'Конопленко', 'Атамась', 'Єрмоленко']
female_firstnames = ['Софія', 'Ніка']
male_firstnames = ['Бодя', 'Саша']
male_patronymics = ['Сергійович', 'Романович', 'Степанович', 'Георгійович']
female_patronymics = ['Сергіївна', 'Романівна', 'Степанівна', 'Георгіївна']
sexes = ['F', 'M']
marks = [1, 2, 3, 4, 5, '-']
scholarships = list(range(1234, 4322))

lines = []
for _ in range(20):
    surname = random.choice(surnames)
    sex = random.choice(sexes)
    if sex == 'F':
        firstname = random.choice(female_firstnames)
        patronymic = random.choice(female_patronymics)
    else:
        firstname = random.choice(male_firstnames)
        patronymic = random.choice(male_patronymics)
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
