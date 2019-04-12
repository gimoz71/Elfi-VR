using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using models;
using System.Collections.Generic;
using System.Collections;

public class JSonConfigManager
{

    public static string ConfigFilePath = "E:/elficonfig/config.json";

    public string FileText { get; set; }
    private static JSonConfigManager instance = null;
    ConfigModel model = new ConfigModel();

    public static JSonConfigManager Instance {
        get {
            if (instance == null) {
                instance = new JSonConfigManager();
            }
            return instance;
        }
    }

    public void OpenConfigFile(string filename) {

        if (File.Exists(filename)) {
            FileText = File.ReadAllText(filename);
            model = JsonUtility.FromJson<ConfigModel>(FileText);
        }
    }

    public List<Domanda> getDomandeSessione() {
        
        var listaDomande = new List<Domanda>();
        try {
            var domandeInSessione = model.setDomandeSessione;
            foreach (var domanda in model.domande)
            {
                foreach (var id in model.setDomandeSessione)
                {
                    if (domanda.idDomanda.Equals(id))
                    {
                        listaDomande.Add(domanda);
                    }
                }
            }
        }
        catch (Exception e) {
            var errore = e;
        }
        
        return listaDomande;

    }

    public string getCombinazioneLucchetto() {
        var combinazione = "";

        try {
            combinazione = model.lucchetto;
        }
        catch (Exception e) {
            var errore = e;
        }

        return combinazione;
    }
}