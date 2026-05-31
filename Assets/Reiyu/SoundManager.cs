using System;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    // BGMのキーをここに追加する
    GameMenu,
    MainGame,
    Result,
    None
}

public enum SFX
{
    // SEのキーをここに追加する
    BiriBiri,
    Bubble,
    Dokaan,
    EnemyDie,
    GameEnd,
    kyuiin,
    LanguageChange,
    Meramera,
    MouseCursor,
    Nyokinyoki,
    NyokinyokiinEffect,
    Result,
    Select,
    Start,
    Supasupa,
    TowerDamage,
    TowerDamageBig,
    None
}

/// <summary>
/// BGMクラス
/// </summary>
[Serializable]
public class BGMPair
{
    public BGM _bgmKey;
    public AudioClip _clip;
}

/// <summary>
/// SFXクラス
/// </summary>
[Serializable]
public class SFXPair
{
    public SFX _sfxKey;
    public AudioClip _clip;
}

/// <summary>
/// サウンドを管理するクラス
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン
    /// </summary>
    private static SoundManager instance;
    public static SoundManager Instance { get => instance; }

    [Header("音量")]
    [SerializeField, Range(0f, 1f)]
    private static float _bgmVolume = 0.5f;

    [SerializeField, Range(0f, 1f)]
    private static float _sfxVolume = 0.5f;

    //音量変更用変数
    public float BgmVolume
    {
        get => _bgmVolume;
        set
        {
            _bgmVolume = Mathf.Clamp01(value);
            if (_bgmSource != null)
                _bgmSource.volume = _bgmVolume;
        }
    }
    public float SfxVolume
    {
        get => _sfxVolume;
        set
        {
            _sfxVolume = Mathf.Clamp01(value);
            if (_sfxSource != null)
                _sfxSource.volume = _sfxVolume;
        }
    }


    [Header("BGM"), SerializeField]
    private BGMPair[] _bgm;

    [Header("SFX"), SerializeField]
    private SFXPair[] _sfx;

    //サウンドをenumから指定できるようにするためのテーブル
    private Dictionary<BGM, AudioClip> _bgmTable;
    private Dictionary<SFX, AudioClip> _sfxTable;

    [Header("BGMを鳴らす用のAudioSource"), SerializeField]
    private AudioSource _bgmSource;
    [Header("SFXを鳴らす用のAudioSource"), SerializeField]
    private AudioSource _sfxSource;

    private void Awake()
    {
        instance = this;
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        BgmVolume = _bgmVolume;
        SfxVolume = _sfxVolume;

        BuildTables();
        SetUpAudioSources();
    }

    /// <summary>
    /// テーブルを生成する関数
    /// </summary>
    private void BuildTables()
    {
        //BGMのテーブル生成
        _bgmTable = new Dictionary<BGM, AudioClip>();
        foreach (var pair in _bgm)
        {
            if (pair._bgmKey == BGM.None || pair._clip == null)
                continue;

            _bgmTable[pair._bgmKey] = pair._clip;
        }

        //SFXのテーブル生成
        _sfxTable = new Dictionary<SFX, AudioClip>();
        foreach (var pair in _sfx)
        {
            if (pair._sfxKey == SFX.None || pair._clip == null)
                continue;

            _sfxTable[pair._sfxKey] = pair._clip;
        }
    }

    /// <summary>
    /// オーディオソースの設定
    /// </summary>
    private void SetUpAudioSources()
    {
        _bgmSource.loop = true;
        _bgmSource.playOnAwake = false;
        _bgmSource.volume = _bgmVolume;

        _sfxSource.loop = false;
        _sfxSource.playOnAwake = false;
        _sfxSource.volume = _sfxVolume;
    }

    // =====================
    // BGM
    // =====================
    public void PlayBGM(BGM key)
    {
        if (!_bgmTable.TryGetValue(key, out var clip))
            return;

        if (_bgmSource.clip == clip && _bgmSource.isPlaying)
            return;

        _bgmSource.Stop();
        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
        _bgmSource.clip = null;
    }

    // =====================
    // SFX
    // =====================
    public void PlaySE(SFX key)
    {
        if (!_sfxTable.TryGetValue(key, out var clip))
            return;

        _sfxSource.PlayOneShot(clip);
    }

    public void StopSE(SFX key)
    {
        _sfxSource.Stop();
        _sfxSource.clip = null;
    }
}
