use std::{io, io::prelude::*};

pub type Error = Box<dyn std::error::Error + Send + Sync>;
pub type Result<T> = std::result::Result<T, Error>;

fn main() -> Result<()> {

    let find_number = | s: String, d: &mut i32, r: bool | -> bool {
        if r {
            if s.ends_with("eno") {
                *d = 1;
                return true;
            } else if s.ends_with("owt") {
                *d = 2;
                return true;
            } else if s.ends_with("eerht") {
                *d = 3;
                return true;
            } else if s.ends_with("ruof") {
                *d = 4;
                return true;
            } else if s.ends_with("evif") {
                *d = 5;
                return true;
            } else if s.ends_with("xis") {
                *d = 6;
                return true;
            } else if s.ends_with("neves") {
                *d = 7;
                return true;
            } else if s.ends_with("thgie") {
                *d = 8;
                return true;
            } else if s.ends_with("enin") {
                *d = 9;
                return true;
            }
        } else {
            if s.ends_with("one") {
                *d = 1;
                return true;
            } else if s.ends_with("two") {
                *d = 2;
                return true;
            } else if s.ends_with("three") {
                *d = 3;
                return true;
            } else if s.ends_with("four") {
                *d = 4;
                return true;
            } else if s.ends_with("five") {
                *d = 5;
                return true;
            } else if s.ends_with("six") {
                *d = 6;
                return true;
            } else if s.ends_with("seven") {
                *d = 7;
                return true;
            } else if s.ends_with("eight") {
                *d = 8;
                return true;
            } else if s.ends_with("nine") {
                *d = 9;
                return true;
            }
        }

        return false;
    };

    let find_digit = |c: char, s: &mut String, d: &mut i32, r: bool| -> bool {
        s.push_str(&c.to_string());

        if find_number(s.to_string(), d, r) {
            return true;
        }

        let parse_result = c.to_string().parse::<i32>();
        if !parse_result.is_err() {
            *d = parse_result.unwrap();
            return true;
        }
        return false;
    };

    let mut acc = 0;
    for line in io::stdin().lock().lines() {
        let ln = line.unwrap();

        

        let mut first_digit: i32 = 0;
        let mut last_digit: i32 = 0;

        let mut s = "".to_owned();
        ln.chars().position(|c| find_digit(c, &mut s,&mut first_digit, false));
        
        s = "".to_owned();
        ln.chars().rev().position(|c| find_digit(c, &mut s, &mut last_digit, true));

        println!("{}{}", first_digit, last_digit);
        acc += first_digit * 10 + last_digit;
    }

    println!("{}", acc);
    Ok(())
}
