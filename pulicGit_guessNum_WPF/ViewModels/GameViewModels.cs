using pulicGit_guessNum_WPF.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace pulicGit_guessNum_WPF.ViewModels;

public class GameViewModels : INotifyPropertyChanged
{
    public ICommand NewGameCommand { get; }
    public ICommand GuessCommand { get; }
    public GameViewModels()
    {
        NewGame(null);
        NewGameCommand = new RelayCommand(NewGame);
        GuessCommand = new RelayCommand(GuessNumber, CanGuessNumber);
    }

    public int PeopleNumber
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(GuessNumber));
        }
    }
    public int RandNumber
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(RandNumber));
        }
    }
    public string ErrorMessage
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
    public int Attempt
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(Attempt));
        }
    }
    public int Score
    {
        get => field;
        set
        {
            field = value;
            OnPropertyChanged(nameof(Score));
        }
    }

    private void NewGame(object parameter)
    {
        Score = 0;
        Attempt = 25;
        ErrorMessage = "";
    }

    private void GuessNumber(object parameter)
    {
        GenerateNumber();
        if (PeopleNumber > RandNumber)
        {
            ErrorMessage = "Число меньше! Попробуй ещё раз";
            Score++;
            Attempt--;
        }
        else if (PeopleNumber < RandNumber)
        {
            ErrorMessage = "Число больше! Попробуй ещё раз";
            Score++;
            Attempt--;
        }
        else if(PeopleNumber == RandNumber)
        {
            ErrorMessage = "Ты угадал число!";
            Score++;
            NewGame(null);
        }

        if(Attempt == 0)
        {
            Attempt = 0;
            NewGame(null);
        }
    }
    private bool CanGuessNumber(object parameter)
    {
        return !string.IsNullOrEmpty(parameter.ToString());
    }

    private int GenerateNumber()
    {
        Random random = new Random();
        RandNumber = random.Next(1, 1000);
        return RandNumber;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

