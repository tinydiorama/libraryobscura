using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, iDataPersistence
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] public List<LetterSlot> letters;
    [SerializeField] public List<Letter> letterDatabase;
    [SerializeField] public List<BookSlot> books;
    [SerializeField] public List<Book> booksDatabase;

    public CutsceneManager cutsceneManager;
    public MailManager mailManager;
    public DayTimeController dayTime;
    public bool isPaused;
    public bool pauseShown;

    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) ) 
        {
            if ( pauseShown )
            {
                StartCoroutine(hidePauseMenu());
            } else
            {
                if ( ! isPaused )
                {
                    StartCoroutine(showPauseMenu());
                }
            }
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    IEnumerator showPauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = true;
        pauseShown = true;
        pauseMenu.SetActive(true);
        pauseMenu.GetComponent<Inventory>().inventoryInitialize();
    }

    IEnumerator hidePauseMenu()
    {
        yield return new WaitForSeconds(0.3f);
        isPaused = false;
        pauseShown = false;
        pauseMenu.SetActive(false);
    }
    
    public void LoadData(GameData data)
    {
        foreach (Letter dbLetter in letterDatabase)
        {
            if (data.letters.ContainsKey(dbLetter.id))
            {
                bool isNew;
                data.letters.TryGetValue(dbLetter.id, out isNew);
                letters.Add(new LetterSlot(dbLetter, isNew));
            }
        }
        foreach (Book dbBook in booksDatabase)
        {
            if (data.books.ContainsKey(dbBook.id))
            {
                bool isNew;
                data.books.TryGetValue(dbBook.id, out isNew);
                books.Add(new BookSlot(dbBook, isNew));
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        foreach (LetterSlot slot in letters)
        {
            if (data.letters.ContainsKey(slot.letter.id))
            {
                data.letters.Remove(slot.letter.id);
            }
            data.letters.Add(slot.letter.id, slot.newLetter);
        }
        foreach (BookSlot slot in books)
        {
            if (data.books.ContainsKey(slot.book.id))
            {
                data.books.Remove(slot.book.id);
            }
            data.books.Add(slot.book.id, slot.newBook);
        }
    }
}
